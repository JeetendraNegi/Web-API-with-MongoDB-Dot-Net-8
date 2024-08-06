using EMS.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Text.Json;

namespace EMS.Services
{
    public class MongoDBContext<T> : IMongoDBContext<T> where T : class
    {
        private readonly IMongoCollection<T> collection;
        private readonly IConfiguration _configuration;

        public MongoDBContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration["MONGODB_URI"];
            var dbName = _configuration["MONGODB_DBNAME"];

            if (connectionString == null)
            {
                Environment.Exit(0);
            }
            var client = new MongoClient(connectionString);
            collection = client.GetDatabase(dbName).GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> GetAll()
        {
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Create(T entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task Update(Guid id, T entity)
        {
            await collection.ReplaceOneAsync(new BsonDocument("_id", id), entity);
        }

        public async Task Delete(Guid id)
        {
            await collection.DeleteOneAsync(new BsonDocument("_id", id));
        }

        public async Task<List<T>> GetEmployeeByCountry(string country)
        {
            var pipeline = new[]
            {
                new BsonDocument("$match",
                    new BsonDocument("Address.Country", country)
                ),
            };

            // Execute the aggregation pipeline
            var employees = await collection.Aggregate<T>(pipeline).ToListAsync();

            return employees;
        }

        public async Task<List<T>> GetEmployeeByDesignation(string designation)
        {
            var filter = Builders<T>.Filter.Eq("Designation", designation);
            var employees = await collection.Find(filter).ToListAsync();
            return employees;
        }

        public async Task<List<T>> GetEmployeesByDepartment(string departmentName)
        {
            // Define the aggregation pipeline
            var pipeline = new[]
            {
                new BsonDocument("$lookup",
                    new BsonDocument
                    {
                        { "from", "Department" },
                        { "localField", "DepartmentId" },
                        { "foreignField", "_id" },
                        { "as", "department" }
                    }
                ),
                new BsonDocument("$unwind",
                    new BsonDocument("path", "$department")
                ),

                new BsonDocument("$match",
                    new BsonDocument("department.Name", departmentName)
                ),

                // Project stage to include only specific fields
                new BsonDocument("$project",
                    new BsonDocument
                    {
                        { "Name", 1 },
                        { "Designation", 1 },
                        { "Address", 1 },
                        { "DepartmentId", 1 }
                    }
                )
            };

            // Execute the aggregation pipeline
            var employees = await collection.Aggregate<T>(pipeline).ToListAsync();

            return employees;
        }

        public async Task<List<EmployeeLoginDTO>> GetEmployeeWithLoginDetails()
        {
            var pipeling = new []
            {
                // Join the Employee and Payroll collections
                new BsonDocument("$lookup",
                new BsonDocument
                    {
                        { "from", "Payroll" },
                        { "localField", "_id" },
                        { "foreignField", "EmployeeId" },
                        { "as", "payroll" }
                    }),
                new BsonDocument("$unwind", "$payroll"),

                // Join the Employee and Department collections
                new BsonDocument("$lookup",
                new BsonDocument
                    {
                        { "from", "Department" },
                        { "localField", "DepartmentId" },
                        { "foreignField", "_id" },
                        { "as", "department" }
                    }),
                new BsonDocument("$unwind", "$department"),

                // Join the Employee and Login collections
                new BsonDocument("$lookup",
                new BsonDocument
                    {
                        { "from", "Login" },
                        { "localField", "_id" },
                        { "foreignField", "EmployeeId" },
                        { "as", "login" }
                    }),
                new BsonDocument("$unwind", "$login"),

                // Project stage to include only specific fields
                new BsonDocument("$project",
                new BsonDocument
                    {
                        { "_id", 0 },
                        { "BasicSalary", "$payroll.BasicSalary" },
                        { "NetSalary", "$payroll.NetSalary" },
                        { "EmployeeName", "$Name" },
                        { "Designation", "$Designation" },
                        { "DepartmentName", "$department.Name" },
                        { "Address", "$Address" },
                        { "UserId", "$login.Username" },
                        { "Password", "$login.Password" }
                    })
            };

            return await collection.Aggregate<EmployeeLoginDTO>(pipeling).ToListAsync();
        }
    }
}

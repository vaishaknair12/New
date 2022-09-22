namespace NewProject.Models
{
    public class EmployeeStoreDatabaseSettings : IEmployeeDatabaseSettins
    {
        //public string EmployeesCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

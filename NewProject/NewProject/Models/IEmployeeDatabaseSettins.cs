namespace NewProject.Models
{
    public interface IEmployeeDatabaseSettins
    {
       // string EmployeesCollectionName { get; set; }
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}

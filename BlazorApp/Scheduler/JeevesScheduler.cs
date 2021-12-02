using BlazorApp.Dtos;
using Dapper;
using System.Data.SqlClient;

namespace BlazorApp.Scheduler
{
    public class JeevesScheduler
    {
        public void LoadProjects()
        {
            using(var cn = new SqlConnection("Server=xxx;Database=xxx;User Id=xxx;Password=xxx;"))
            {
                // GET LAST 100 PROJECTS FROM JEEVES
                var sql = "SELECT TOP(100) ProjCode as Project, ProjDescr as Description FROM prj ORDER BY RowCreatedDt DESC";
                var projects = cn.Query<ProjectDto>(sql: sql).ToList();
                Cache.SetProjects(projects);
            }
        }
    }
}

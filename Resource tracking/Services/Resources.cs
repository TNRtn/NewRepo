using Microsoft.EntityFrameworkCore;
using Resource_tracking.Controllers;
using Resource_tracking.Data;
using Resource_tracking.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resource_tracking.Services
{
    public class ResourcesService
    {
        public readonly AppDbContext cs;

        public ResourcesService(AppDbContext cs)
        {
            this.cs = cs;
        }

        public List<Resources_params_Result> GetResources(Resources_Input_params searchfilter)
        {
            try
            {
                Console.WriteLine(JsonSerializer.Serialize(searchfilter));
                return cs.Database
                    .SqlQueryRaw<Resources_params_Result>(
                        "EXEC dbo.spGetResoureces @Id = {0}, @Name = {1}, @CategoryId = {2}, @RevisionCount= {3} ", searchfilter.Id, searchfilter.Name, searchfilter.CategoryId, searchfilter.RevisionCount
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving resources: {ex.Message}", ex
                );
            }
        }

        public void AddResources(Resources_Add_Params inputdata)
        {
            try
            {
                cs.Database.ExecuteSqlRaw("EXEC spAddResource @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",inputdata.Id, inputdata.Name, inputdata.Description, inputdata.CategoryId, inputdata.ReferenceKeys, inputdata.ReferenceNoteLinks, inputdata.KeyPoints,inputdata.RevisionCount);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding Resource: {ex.Message}", ex);
            }

        }

        public void DeleteResource(int id)
        {
            try
            {
                cs.Database.ExecuteSqlRaw("EXEC spDeleteResource @Id={0}", id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting category : {ex.Message}");
            }
        }
    }
}

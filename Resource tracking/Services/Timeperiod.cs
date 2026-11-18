using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class TimeperiodService
    {
        private readonly AppDbContext cs;
        public TimeperiodService(AppDbContext cs)
        {
            this.cs = cs;
        }

        public List<TimePeriod_Params> GetTimePeriods(
      Timperiod_Input_params searchFilter)
        {
            try
            {
                return cs.Set<TimePeriod_Params>()
                    .FromSqlRaw(
                        @"EXEC dbo.spGetAllTimePeriods
                @Id = {0},
                @CategoryId = {1},
                @SearchName = {2},
                @SortOrder = {3}",
                        searchFilter.Id,
                        searchFilter.CategoryId,
                        searchFilter.Name,
                        searchFilter.SortOrder ?? "DESC"
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Timeperiods: {ex.Message}", ex);
            }
        }


        public void AddTimeperiod(Timperiod_Add_params adddata)
        {
            try
            {
                cs.Database.ExecuteSqlRaw("EXEC dbo.spSaveTimePeriod @p0, @p1, @p2, @p3, @p4, @p5, @p6", adddata.Id, adddata.Name, adddata.PeriodDate, adddata.Description, adddata.CategoryId, adddata.KeyNotes, adddata.KeyReferenceLinks);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding timeperiod : {ex.Message}");
            }
        }

        public void deleteTimperiod(int id)
        {
            try
            {
                cs.Database.ExecuteSqlRaw("EXEC spDeleteTimePeriod @Id={0}", id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting timeperiod : {ex.Message}");
            }
        }
    }
}

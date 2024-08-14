using IngaCode.Domain.Entities;
using IngaCode.Domain.Interfaces;
using System.Data;
using Dapper;

namespace IngaCode.Infrastructure.Repository
{
    public class TimeTrackerRepository : ITimeTrackerRepository
    {
        private readonly IDbConnection _dbConnection;

        public TimeTrackerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddAsync(TimeTracker entity)
        {
            var query = @"
                INSERT INTO time_tracker (id_time_tracker, start_date_time_tracker, end_date_time_tracker, time_zone_id, task_id, collab_id, createdAt_time_tracker, updatedAt_time_tracker, deletedAt_time_tracker)
                VALUES (@Id, @StartDate, @EndDate, @TimeZoneId, @TaskId, @CollaboratorId, @CreatedAt, @UpdatedAt, @DeletedAt)";

            await _dbConnection.ExecuteAsync(query, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM time_tracker WHERE id_time_tracker = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<TimeTracker>> GetAllAsync()
        {
            var query = "SELECT * FROM time_tracker";
            return await _dbConnection.QueryAsync<TimeTracker>(query);
        }

        public async Task<TimeTracker> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM time_tracker WHERE id_time_tracker = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<TimeTracker>(query, new { Id = id });
        }

        public async Task<IEnumerable<TimeTracker>> GetByTaskIdAsync(Guid taskId)
        {
            var query = "SELECT * FROM time_tracker WHERE task_id = @TaskId";
            return await _dbConnection.QueryAsync<TimeTracker>(query, new { TaskId = taskId });
        }

        public async Task<IEnumerable<TimeTracker>> GetByCollaboratorIdAsync(Guid collaboratorId)
        {
            var query = "SELECT * FROM time_tracker WHERE collab_id = @CollaboratorId";
            return await _dbConnection.QueryAsync<TimeTracker>(query, new { CollaboratorId = collaboratorId });
        }

        public async Task UpdateAsync(TimeTracker entity)
        {
            var query = @"
                UPDATE time_tracker
                SET start_date_time_tracker = @StartDate, end_date_time_tracker = @EndDate, time_zone_id = @TimeZoneId,
                    task_id = @TaskId, collab_id = @CollaboratorId, createdAt_time_tracker = @CreatedAt,
                    updatedAt_time_tracker = @UpdatedAt, deletedAt_time_tracker = @DeletedAt
                WHERE id_time_tracker = @Id";

            await _dbConnection.ExecuteAsync(query, entity);
        }
    }
}

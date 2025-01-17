using ECF2.Models;
using MongoDB.Driver;
namespace ECF2.Services
{
    public class StatisticService
    {

        private readonly IMongoRepository<Statistic> _statisticRepository;

        public StatisticService(IMongoRepository<Statistic> statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
    }
}

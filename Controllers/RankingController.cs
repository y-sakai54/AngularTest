using AngularTest.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AngularTest.Controllers;

[ApiController]
[Route("[controller]")]
public class RankingController : ControllerBase
{
    private readonly ILogger<RankingController> _logger;

    public RankingController(ILogger<RankingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<RankingDto> Get()
    {
        // テストデータ作る
        List<RankingDto> rankingList = new List<RankingDto>();
        for(int i = 1; i < 10; i++)
        {
            RankingDto data = new RankingDto()
            {
                Rank = i,
                Name = $"NAME{i}",
            };
            rankingList.Add(data);
        }
        return rankingList;
    }
}


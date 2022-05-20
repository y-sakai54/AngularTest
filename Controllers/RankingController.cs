using AngularTest.Dto;
using AngularTest.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularTest.Controllers;

[ApiController]
[Route("[controller]")]
public class RankingController : ControllerBase
{
    private readonly MyDbContext _context;

    private readonly ILogger<RankingController> _logger;

    public RankingController(MyDbContext context, ILogger<RankingController> logger)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// 全てのデータを返す
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<Ranking>> Get()
    {
        return  await _context.Rankings.ToListAsync();
    }

    /// <summary>
    /// データを追加する。
    /// </summary>
    [HttpPost]
    public async Task<IEnumerable<Ranking>> add([FromBody] Ranking addData)
    {
        _context.Rankings.Add(addData);
        await _context.SaveChangesAsync();

        return await _context.Rankings.ToListAsync();
    }
}


using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTochka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAll()
    {
        var reviews = await _unitOfWork.Reviews.GetAllAsync();
        var dto = reviews.Select(r => new ReviewDto
        {
            Id = r.Id,
            AuthorName = r.AuthorName,
            Text = r.Text,
            Rating = r.Rating,
            CreatedAt = r.CreatedAt
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> Get(int id)
    {
        var review = await _unitOfWork.Reviews.GetByIdAsync(id);
        if (review == null) return NotFound();
        return Ok(new ReviewDto
        {
            Id = review.Id,
            AuthorName = review.AuthorName,
            Text = review.Text,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        });
    }

    [HttpPost]
    public async Task<ActionResult<ReviewDto>> Create(ReviewCreateDto dto)
    {
        var review = new Review
        {
            AuthorName = dto.AuthorName,
            Text = dto.Text,
            Rating = dto.Rating,
            CreatedAt = DateTime.UtcNow
        };
        await _unitOfWork.Reviews.AddAsync(review);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = review.Id }, new ReviewDto
        {
            Id = review.Id,
            AuthorName = review.AuthorName,
            Text = review.Text,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ReviewCreateDto dto)
    {
        var review = await _unitOfWork.Reviews.GetByIdAsync(id);
        if (review == null) return NotFound();
        review.AuthorName = dto.AuthorName;
        review.Text = dto.Text;
        review.Rating = dto.Rating;
        _unitOfWork.Reviews.Update(review);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var review = await _unitOfWork.Reviews.GetByIdAsync(id);
        if (review == null) return NotFound();
        _unitOfWork.Reviews.Delete(review);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

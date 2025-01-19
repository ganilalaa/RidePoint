using RidePoint.Models.Entities;
using System.Threading.Tasks;

namespace RidePoint.Interfaces
{
    public interface IReviewService
    {
        Task<bool> SubmitReviewAsync(UserReview review, int? userId);
    }
}
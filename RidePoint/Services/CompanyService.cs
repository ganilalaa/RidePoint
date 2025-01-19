using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RidePoint.Data;
using RidePoint.Interfaces;
using RidePoint.Models.Enums;
using RidePoint.Models.Utilities;
using System.Threading.Tasks;

namespace RidePoint.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public CompanyService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<int?> GetCompanyForCurrentUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.Session?.GetInt32("UserId");
            if (!userId.HasValue)
            {
                throw new UnauthorizedAccessException(ResponseMessages.Unauthorized);
            }

            var user = await _context.Users.FindAsync(userId.Value);
            if (user == null)
            {
                throw new KeyNotFoundException(ResponseMessages.NotFound);
            }

            if (user.BusinessType != BusinessType.TaxiCompany)
            {
                throw new ForbiddenAccessException(ResponseMessages.Forbidden);
            }

            var company = await _context.TaxiCompanies.FirstOrDefaultAsync(c => c.UserId == user.UserId);
            if (company == null)
            {
                throw new KeyNotFoundException(ResponseMessages.NotFound);
            }

            return company.TaxiCompanyId;
        }
    }

    public class ForbiddenAccessException : InvalidOperationException
    {
        public ForbiddenAccessException(string message) : base(message) { }
    }
}
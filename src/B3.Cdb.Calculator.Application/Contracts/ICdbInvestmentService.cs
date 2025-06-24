using B3.Cdb.Calculator.Domain.Dto.Request;
using B3.Cdb.Calculator.Domain.Dto.Response;

namespace B3.Cdb.Calculator.Application.Contracts
{
    public interface ICdbInvestmentService
    {
        Response<CdbInvestmentResponseDto> CalculateCdbInvestment(CdbInvestmentRequestDto dto);
    }
}

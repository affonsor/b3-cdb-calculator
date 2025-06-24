using B3.Cdb.Calculator.Application.Contracts;
using B3.Cdb.Calculator.Domain.Dto.Request;
using B3.Cdb.Calculator.Domain.Dto.Response;
using B3.Cdb.Calculator.Domain.Entitie;
using B3.Cdb.Calculator.Domain.Resource;
using Microsoft.Extensions.Logging;

namespace B3.Cdb.Calculator.Application.Services
{
    public class CdbInvestmentService(ILogger<CdbInvestmentService> logger) : ICdbInvestmentService
    {
        private readonly ILogger<CdbInvestmentService> _logger = logger;
        public Response<CdbInvestmentResponseDto> CalculateCdbInvestment(CdbInvestmentRequestDto dto)
        {
            _logger.LogInformation(Messages.ServiceStart, nameof(CdbInvestmentService));

            try
            {
                var investment = new CdbInvestment(dto.InitialValue);
                investment.Calculate(dto.Months);

                var responseDto = new CdbInvestmentResponseDto
                {
                    GrossReturn = investment.GrossReturn,
                    NetReturn = investment.NetReturn
                };

                _logger.LogInformation(Messages.CalculationSuccessLog, dto.InitialValue, dto.Months);
                return new Response<CdbInvestmentResponseDto>(200, Messages.CalculationSuccess, responseDto);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "An exception occurred: {Message}", ex.Message);
                return new Response<CdbInvestmentResponseDto>(400, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Messages.UnexpectedError);
                return new Response<CdbInvestmentResponseDto>(500, Messages.UnexpectedError);
            }
            finally
            {
                _logger.LogInformation(Messages.ServiceEnd, nameof(CdbInvestmentService));
            }
        }
    }
}

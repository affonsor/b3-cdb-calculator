namespace B3.Cdb.Calculator.Domain.Resource
{
    public static class Messages
    {
        public const string ServiceStart = "Iniciando {ServiceName}.";
        public const string ServiceEnd = "Finalizando {ServiceName}.";
        public const string CalculationSuccessLog = "Cálculo concluído com sucesso para valor inicial: {InitialValue}, meses: {Months}.";
        public const string InvalidInitialValue = "O valor inicial deve ser maior que zero.";
        public const string InvalidPeriod = "O período deve ser maior que 1 para ser válido.";
        public const string CalculationSuccess = "Cálculo concluído com sucesso.";
        public const string UnexpectedError = "Ocorreu um erro inesperado ao calcular o investimento em CDB.";
    }
}
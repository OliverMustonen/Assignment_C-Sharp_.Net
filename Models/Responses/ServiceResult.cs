using C_Sharp_.Net_Address_Book.Enums;
using C_Sharp_.Net_Address_Book.Intefaces;

namespace C_Sharp_.Net_Address_Book.Models.Responses;

public class ServiceResult : IServiceResult
{
    public ServiceStatus Status { get; set; }
    public object Result { get; set; } = null!;
}


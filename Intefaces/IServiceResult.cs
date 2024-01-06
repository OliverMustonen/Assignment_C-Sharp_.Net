using C_Sharp_.Net_Address_Book.Enums;

namespace C_Sharp_.Net_Address_Book.Intefaces;

public interface IServiceResult
{
    object Result { get; set; }
    ServiceStatus Status { get; set; }
}

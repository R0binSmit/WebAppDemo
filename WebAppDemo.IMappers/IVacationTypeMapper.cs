using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.VacationType;

namespace WebAppDemo.IMappers;

public interface IVacationTypeMapper
{
    VacationType Map(CreateVacationTypeDto createVacationTypeDto);
    VacationType Map(UpdateVacationTypeDto updateVacationTypeDto);
    GetVacationTypeDto Map(VacationType vacationType);
    List<GetVacationTypeDto> Map(List<VacationType> vacationTypes);
}

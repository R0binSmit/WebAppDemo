using Riok.Mapperly.Abstractions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.VacationType;
using WebAppDemo.IMappers;

namespace WebAppDemo.Mappers;

[Mapper]
public partial class VacationTypeMapper : IVacationTypeMapper
{
    public partial VacationType Map(CreateVacationTypeDto createVacationTypeDto);

    public partial VacationType Map(UpdateVacationTypeDto updateVacationTypeDto);

    public partial GetVacationTypeDto Map(VacationType vacationType);

    public partial List<GetVacationTypeDto> Map(List<VacationType> vacationTypes);
}

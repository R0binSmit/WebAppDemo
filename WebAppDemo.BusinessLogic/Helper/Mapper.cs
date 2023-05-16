using Riok.Mapperly.Abstractions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.VacationType;

namespace WebAppDemo.BusinessLogic.Helper;

[Mapper]
public partial class Mapper
{
    private static Mapper? _mapper;

    private Mapper()
    {

    }

    public static Mapper GetMapper()
    {
        if (_mapper == null)
        {
            _mapper = new Mapper();
        }

        return _mapper;
    }

    public partial VacationType Map(CreateVacationTypeDto createVacationTypeDto);
    public partial VacationType Map(UpdateVacationTypeDto updateVacationTypeDto);
    public partial GetVacationTypeDto Map(VacationType vacationType);
    public partial List<GetVacationTypeDto> Map(List<VacationType> vacationTypes);
}

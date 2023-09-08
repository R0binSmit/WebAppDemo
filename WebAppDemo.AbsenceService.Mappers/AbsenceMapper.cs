using Riok.Mapperly.Abstractions;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Absence;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Mappers;

[Mapper]
public partial class AbsenceMapper : IAbsenceMapper
{
    public partial GetAbsenceDto Map(Absence absence);
    public partial List<GetAbsenceDto> Map(List<Absence> absences);
}

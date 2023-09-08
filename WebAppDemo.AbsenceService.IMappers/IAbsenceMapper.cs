using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Absence;

namespace WebAppDemo.AbsenceService.IMappers;

public interface IAbsenceMapper
{
    GetAbsenceDto Map(Absence absence);
    List<GetAbsenceDto> Map(List<Absence> absences);
}

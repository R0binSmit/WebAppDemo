using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.AbsenceType;

namespace WebAppDemo.AbsenceService.IMappers;

public interface IAbsenceTypeMapper
{
    GetAbsenceTypeDto Map(AbsenceType absenceType);
    List<GetAbsenceTypeDto> Map(List<AbsenceType> absenceTypes);
}

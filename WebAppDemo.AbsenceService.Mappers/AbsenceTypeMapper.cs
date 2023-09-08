using Riok.Mapperly.Abstractions;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.AbsenceType;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Mappers;

[Mapper]
public partial class AbsenceTypeMapper : IAbsenceTypeMapper
{
    public partial GetAbsenceTypeDto Map(AbsenceType absenceType);
    public partial List<GetAbsenceTypeDto> Map(List<AbsenceType> absenceTypes);
}

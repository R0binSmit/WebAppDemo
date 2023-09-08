using Riok.Mapperly.Abstractions;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.State;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Mappers;

[Mapper]
public partial class StateMapper : IStateMapper
{
    public partial GetStateDto Map(State state);
    public partial List<GetStateDto> Map(List<State> states);
}

using BAF.UseCases.Symbol.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Queries.GetOpenPositions
{
    public class GetOpenPositionsQuery: IRequest<IList<OpenPositionDto>>
    {
    }
}

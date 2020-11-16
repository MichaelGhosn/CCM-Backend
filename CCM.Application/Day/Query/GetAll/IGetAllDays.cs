using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Day.Query.GetAll
{
    public class IGetAllDays: IRequest<ResponseModel<List<GetAllDaysResponseModel>>>
    {
        
    }
}
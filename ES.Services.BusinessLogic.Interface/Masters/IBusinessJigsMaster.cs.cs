﻿using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Masters
{
    public interface IBusinessJigsMaster
    {
        AddJigsMasterResponseDto AddJigsMaster(AddJigsMasterRequestDto addJigsMasterRequestDto);

        UpdateJigsMasterResponseDto UpdateJigsMaster(UpdateJigsMasterRequestDto updateJigsMasterRequestDto);

    }
}

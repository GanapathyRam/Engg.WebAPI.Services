﻿using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Masters
{
    public interface IBusinessParameterMaster
    {
        AddParameterMasterResponseDto AddParameterMaster(AddParameterMasterRequestDto addParameterMasterRequestDto);

        UpdateParameterMasterResponseDto UpdateParameterMaster(UpdateParameterMasterRequestDto updateParameterMasterRequestDto);
    }
}

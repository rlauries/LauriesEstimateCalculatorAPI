﻿using LauriesEC.Fences.Repositories.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.Interfaces
{
    public interface ISupplier
    {
        MaterialsModel GetMaterialPriceById(MaterialsName materialsName);
    }
}

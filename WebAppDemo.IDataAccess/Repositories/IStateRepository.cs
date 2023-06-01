﻿using WebAppDemo.IBusinessLogic.Interfaces.Repositories;

namespace WebAppDemo.IDataAccess.Repositories;

public  interface IStateRepository<T> : IGenericRepository<T>
{
    Task<bool> IsNameAward(string name);
}

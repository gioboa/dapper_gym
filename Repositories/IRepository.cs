using System;
using System.Collections.Generic;
interface IRepository<T> where T : class
{
  List<T> GetAll();
  bool Add(T employee);
  T GetById(int id);
  bool Update(T employee);
  bool Delete(int id);
}
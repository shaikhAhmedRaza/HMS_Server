using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class DishCategoryService : IDishCategoryService
    {
        IDbHelper dbHelper;

        public DishCategoryService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        string selectQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Name]
                                  ,[HotelId]
                                  ,[gstCompliance]
                                  ,[status]
                              FROM[dbo].[DishCategory]";
        string selectByHotelQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Name]
                                  ,[HotelId]
                                  ,[gstCompliance]
                                  ,[status]
                              FROM[dbo].[DishCategory]
                                   where [CreatedBy] = @CreatedBy";
        string insertQuery = @"INSERT INTO [dbo].[DishCategory]
                                   ([IsActive]
                                   ,[CreatedOn]
                                   ,[CreatedBy]
                                   ,[UpdatedOn]
                                   ,[UpdatedBy]
                                   ,[Name]
                                   ,[HotelId]
                                   ,[gstCompliance]
                                   ,[status])
                             VALUES
                                   (@IsActive
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy
                                   ,@Name
                                   ,@HotelId
                                   ,@gstCompliance
                                   ,@status)";
        string updateQuery = @"UPDATE [dbo].[DishCategory]
                                   SET [IsActive] =@IsActive
                                      ,[CreatedOn] =@CreatedOn
                                      ,[CreatedBy] =@CreatedBy
                                      ,[UpdatedOn] =@UpdatedOn
                                      ,[UpdatedBy] =@UpdatedBy
                                      ,[Name] =@Name
                                      ,[HotelId] =@HotelId
                                      ,[gstCompliance]=@gstCompliance
                                      ,[status]=@status
                                 WHERE Id=@Id";
        string deleteQuery = "Delete from DishCategory";
        public void Add(IModel model)
        {
            var dishCategory = (DishCategory)model;
            dishCategory.IsActive = true;
            dbHelper.Add(insertQuery, dishCategory);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new DishCategory { Id = id });
        }

        public IList<DishCategory> GetAll<DishCategory>()
        {
            var dishCategoryList = dbHelper.FetchData<DishCategory>($"{selectQuery}");
            return dishCategoryList;
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel model)
        {
            var dishCategory = (DishCategory)model;
           
            dbHelper.Update(updateQuery, dishCategory);
        }

        public IList<DishCategory> GetAllByHotelId<DishCategory>(int id)
        {
            var obj = new { CreatedBy = id };
            var dishCategoryList = dbHelper.FetchDataByParam<DishCategory>(selectByHotelQuery,obj);
            return dishCategoryList;
        }
    }
}

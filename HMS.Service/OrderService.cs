﻿using HMS.Domain;
using System;
using System.Collections.Generic;

namespace HMS.Service
{
    public class OrderService : IOrderService
    {
        IDbHelperOrder _dbHelper;
        string orderAddQuery = @"INSERT INTO [dbo].[DishOrder]
                               ([DeliveryTotal]
                               ,[GrossTotal]
                               ,[ItemCount]
                               ,[ItemTotal]
                               ,[AdminId]  
                               ,[DeliveryOptionId]
                               ,[PaymentMode]
                               ,[UserId]
                               ,[CreatedOn]
                               ,[CreatedBy]
                               ,[UpdatedOn]
                               ,[UpdatedBy]
                               ,[IsActive])
                         VALUES
                               (@DeliveryTotal
                               ,@GrossTotal
                               ,@ItemCount
                               ,@ItemTotal
                               ,@AdminId
                               ,@DeliveryOptionId
                               ,@PaymentMode
                               ,@UserId
                               ,@CreatedOn
                               ,@CreatedBy
                               ,@UpdatedOn
                               ,@UpdatedBy
                               ,@IsActive)";
        string orderItemAddQuery = @"INSERT INTO [dbo].[OrderItem]
                                   ([Quantity]
                                   ,[ProductId]
                                   ,[Price]
                                   ,[GstCompliance]
                                   ,[GstPrice]
                                   ,[IsFull]
                                   ,[OrderID]
                                   ,[IsActive]
                                   ,[CreatedOn]
                                   ,[CreatedBy]
                                   ,[UpdatedOn]
                                   ,[UpdatedBy])
                             VALUES
                                   (@Quantity
                                   ,@ProductId
                                   ,@Price
                                   ,@GstCompliance
                                   ,@GstPrice
                                   ,@IsFull
                                   ,@OrderID
                                   ,@IsActive
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy)";
        string orderStatusAddQuery = @"INSERT INTO [dbo].[OrderStatus]
                                       ([OrderId]
                                       ,[Status]
                                       ,[IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy])
                                 VALUES
                                       (@OrderId
                                       ,@Status
                                       ,@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy)";
        string selectByHotelQuery = @"SELECT o.[Id]
                                      ,o.[DeliveryTotal]
                                      ,o.[GrossTotal]
                                      ,o.[ItemCount]
                                      ,o.[ItemTotal]
                                      ,o.[AdminId]
                                      ,o.[DeliveryOptionId]
                                      ,o.[PaymentMode]
                                      ,o.[UserId]
                                      ,o.[CreatedOn]
                                      ,o.[CreatedBy]
                                      ,o.[UpdatedOn]
                                      ,o.[UpdatedBy]
                                      ,o.[IsActive]
									  ,us.UserName as UserName
									  ,us.[Contact] as UserMobileNumber
									  ,(SELECT Top 1 
									  [Status]
  FROM [hms_db].[dbo].[OrderStatus]where OrderId=o.Id order by Id desc) status
                                  FROM [dbo].[DishOrder] o
								  inner join Userconfig us on Us.Id=o.userId
                                    where o.[CreatedBy] =@CreatedBy and 
									cast(o.[CreatedOn] as Date) = cast(getdate() as Date)
								order by UpdatedOn desc";
        string selectStatusByOrderIdQuery = @"select Id,
                                        OrderId,
                                        Status,
                                        IsActive,
                                        CreatedOn,
                                        CreatedBy,
                                        UpdatedOn,
                                        UpdatedBy from OrderStatus where OrderId = @id order by UpdatedOn asc";
        public OrderService(IDbHelperOrder dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public void Add(IModel model)
        {
            var order = (DishOrder)model;
            order.IsActive = true;
           
            _dbHelper.OrderTransaction(order,orderAddQuery,orderItemAddQuery,orderStatusAddQuery);
        }
        public void AddStatus(OrderStatus status)
        {
            status.IsActive = true;
            _dbHelper.Add(orderStatusAddQuery, status);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IList<DishOrder> GetAllByHotelId<DishOrder>(int id)
        {
            var obj = new { CreatedBy = id };
            var orderList = _dbHelper.FetchDataByParam<DishOrder>(selectByHotelQuery, obj);
            return orderList;
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderStatus> GetStatusByOrderId(int OrderId)
        {
            var obj = new { id = OrderId};
            var orderstatus = _dbHelper.FetchDataByParam<OrderStatus>(selectStatusByOrderIdQuery, obj);
            return (List<OrderStatus>)orderstatus;
        }

        public void Update(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
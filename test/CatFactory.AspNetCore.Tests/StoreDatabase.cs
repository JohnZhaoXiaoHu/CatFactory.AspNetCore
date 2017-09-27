﻿using System;
using System.Collections.Generic;
using CatFactory.Mapping;

namespace CatFactory.AspNetCore.Tests
{
    public static class StoreDatabase
    {
        public static Database Mock
        {
            get
            {
                var db = new Database
                {
                    Name = "Store",
                    Tables = new List<Table>()
                    {
                        new Table
                        {
                            Schema = "dbo",
                            Name = "EventLog",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "EventLogID", Type = "uniqueidentifier", Nullable = false },
                                new Column { Name = "EventType", Type = "int", Nullable = false },
                                new Column { Name = "Key", Type = "varchar", Length = 255, Nullable = false },
                                new Column { Name = "Message", Type = "varchar", Nullable = false },
                                new Column { Name = "EntryDate", Type = "datetime", Nullable = false }
                            }
                        },

                        new Table
                        {
                            Schema = "dbo",
                            Name = "ChangeLog",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "ChangeLogID", Type = "int", Nullable = false },
                                new Column { Name = "ClassName", Type = "varchar", Length = 128, Nullable = false },
                                new Column { Name = "PropertyName", Type = "varchar", Length = 128, Nullable = false },
                                new Column { Name = "Key", Type = "varchar", Length = 255, Nullable = false },
                                new Column { Name = "OriginalValue", Type = "varchar", Nullable = true },
                                new Column { Name = "CurrentValue", Type = "varchar", Nullable = true },
                                new Column { Name = "UserName", Type = "varchar", Length = 25, Nullable = false },
                                new Column { Name = "ChangeDate", Type = "varchar", Length = 128, Nullable = false }
                            },
                            Identity = new Identity { Name = "ChangeLogID", Seed = 1, Increment = 1 }
                        },

                        new Table
                        {
                            Schema = "dbo",
                            Name = "ChangeLogExclusion",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "ChangeLogExclusionID", Type = "varchar", Length = 25, Nullable = false },
                                new Column { Name = "TableName", Type = "varchar", Length = 128, Nullable = false },
                                new Column { Name = "ColumnName", Type = "varchar", Length = 128, Nullable = false }
                            }
                        },

                        new Table
                        {
                            Schema = "HumanResources",
                            Name = "Employee",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "EmployeeID", Type = "int", Nullable = false },
                                new Column { Name = "FirstName", Type = "varchar", Length = 25, Nullable = false },
                                new Column { Name = "MiddleName", Type = "varchar", Length = 25, Nullable = true },
                                new Column { Name = "LastName", Type = "varchar", Length = 25, Nullable = false },
                                new Column { Name = "BirthDate", Type = "datetime", Nullable = false }
                            },
                            Identity = new Identity { Name = "EmployeeID", Seed = 1, Increment = 1 }
                        },

                        new Table
                        {
                            Schema = "Production",
                            Name = "ProductCategory",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "ProductCategoryID", Type = "int", Nullable = false },
                                new Column { Name = "ProductCategoryName", Type = "varchar", Length = 100, Nullable = false },
                            },
                            Identity = new Identity { Name = "ProductCategoryID", Seed = 1, Increment = 1 },
                            Uniques = new List<Unique>()
                            {
                                new Unique(new String[] { "ProductCategoryName" }) { ConstraintName = "U_ProductCategoryName" }
                            }
                        },

                        new Table
                        {
                            Schema = "Production",
                            Name = "Warehouse",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "WarehouseID", Type = "varchar", Length = 5, Nullable = false },
                                new Column { Name = "WarehouseName", Type = "varchar", Length = 100, Nullable = false }
                            }
                        },

                        new Table
                        {
                            Schema = "Production",
                            Name = "Product",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "ProductID", Type = "int", Nullable = false },
                                new Column { Name = "ProductName", Type = "varchar", Length = 100, Nullable = false },
                                new Column { Name = "ProductCategoryID", Type = "int", Nullable = false },
                                new Column { Name = "UnitPrice", Type = "decimal", Prec = 8, Scale = 4, Nullable = false },
                                new Column { Name = "Description", Type = "varchar", Length = 255, Nullable = true },
                                new Column { Name = "Discontinued", Type = "bit", Nullable = false }
                            },
                            Identity = new Identity { Name = "ProductID", Seed = 1, Increment = 1 },
                            Uniques = new List<Unique>()
                            {
                                new Unique(new String[] { "ProductName" }) { ConstraintName = "U_ProductName" }
                            }
                        },

                        new Table
                        {
                            Schema = "Production",
                            Name = "ProductInventory",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "ProductInventoryID", Type = "int", Nullable = false },
                                new Column { Name = "ProductID", Type = "int", Nullable = false },
                                new Column { Name = "WarehouseID", Type = "varchar", Length = 5, Nullable = false },
                                new Column { Name = "EntryDate", Type = "datetime", Nullable = false },
                                new Column { Name = "Quantity", Type = "int", Nullable = false },
                                new Column { Name = "Stocks", Type = "int", Nullable = false }
                            },
                            Identity = new Identity { Name = "ProductInventoryID", Seed = 1, Increment = 1 }
                        },

                        new Table
                        {
                            Schema = "Sales",
                            Name = "Customer",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "CustomerID", Type = "int", Nullable = false },
                                new Column { Name = "CompanyName", Type = "varchar", Length = 100, Nullable = true },
                                new Column { Name = "ContactName", Type = "varchar", Length = 100, Nullable = true }
                            },
                            Identity = new Identity { Name = "CustomerID", Seed = 1, Increment = 1 },
                            Uniques = new List<Unique>()
                            {
                                new Unique(new String[] { "CompanyName" }) { ConstraintName = "U_CompanyName" }
                            }
                        },

                        new Table
                        {
                            Schema = "Sales",
                            Name = "Shipper",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "ShipperID", Type = "int", Nullable = false },
                                new Column { Name = "CompanyName", Type = "varchar", Length = 100, Nullable = true },
                                new Column { Name = "ContactName", Type = "varchar", Length = 100, Nullable = true }
                            },
                            Identity = new Identity { Name = "ShipperID", Seed = 1, Increment = 1 },
                            Uniques = new List<Unique>()
                            {
                                new Unique(new String[] { "CompanyName" }) { ConstraintName = "U_CompanyName" }
                            }
                        },

                        new Table
                        {
                            Schema = "Sales",
                            Name = "OrderStatus",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "OrderStatusID", Type = "smallint", Nullable = false },
                                new Column { Name = "Description", Type = "varchar", Length = 100, Nullable = true }
                            }
                        },

                        new Table
                        {
                            Schema = "Sales",
                            Name = "Order",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "OrderID", Type = "int", Nullable = false },
                                new Column { Name = "OrderStatusID", Type = "smallint", Nullable = false },
                                new Column { Name = "OrderDate", Type = "datetime", Nullable = false },
                                new Column { Name = "CustomerID", Type = "int", Nullable = false },
                                new Column { Name = "EmployeeID", Type = "int", Nullable = true },
                                new Column { Name = "ShipperID", Type = "int", Nullable = false },
                                new Column { Name = "Total", Type = "decimal", Prec = 12, Scale = 4, Nullable = false },
                                new Column { Name = "Comments", Type = "varchar", Length = 255, Nullable = true }
                            },
                            Identity = new Identity { Name = "OrderID", Seed = 1, Increment = 1 }
                        },

                        new Table
                        {
                            Schema = "Sales",
                            Name = "OrderDetail",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "OrderDetailID", Type = "int", Nullable = false },
                                new Column { Name = "OrderID", Type = "int", Nullable = false },
                                new Column { Name = "ProductID", Type = "int", Nullable = false },
                                new Column { Name = "ProductName", Type = "varchar", Length = 255, Nullable = false },
                                new Column { Name = "UnitPrice", Type = "decimal", Prec = 8, Scale = 4, Nullable = false },
                                new Column { Name = "Quantity", Type = "int", Nullable = false },
                                new Column { Name = "Total", Type = "decimal", Prec = 8, Scale = 4, Nullable = false }
                            },
                            Identity = new Identity { Name = "OrderDetailID", Seed = 1, Increment = 1 }
                        }
                    },
                    Views = new List<View>()
                    {
                        new View
                        {
                            Schema = "Sales",
                            Name = "OrderSummary",
                            Columns = new List<Column>()
                            {
                                new Column { Name = "OrderID", Type = "int", Nullable = false },
                                new Column { Name = "OrderDate", Type = "datetime", Nullable = false },
                                new Column { Name = "CustomerName", Type = "varchar", Length = 100, Nullable = false },
                                new Column { Name = "EmployeeName", Type = "varchar", Length = 100, Nullable = false },
                                new Column { Name = "ShipperName", Type = "varchar", Length = 100, Nullable = false },
                                new Column { Name = "OrderLines", Type = "int", Nullable = false }
                            }
                        }
                    }
                };

                foreach (var item in db.Tables)
                {
                    db.DbObjects.Add(new DbObject { Schema = item.Schema, Name = item.Name, Type = "USER_TABLE" });
                }

                foreach (var item in db.Views)
                {
                    db.DbObjects.Add(new DbObject { Schema = item.Schema, Name = item.Name, Type = "VIEW" });
                }

                db.SetPrimaryKeyToTables();

                db.LinkTables();

                var columns = new Column[]
                {
                    new Column { Name = "CreationUser", Type = "varchar", Length = 25, Nullable = false },
                    new Column { Name = "CreationDateTime", Type = "datetime", Nullable = false },
                    new Column { Name = "LastUpdateUser", Type = "varchar", Length = 25, Nullable = true },
                    new Column { Name = "LastUpdateDateTime", Type = "datetime", Nullable = true },
                    new Column { Name = "Timestamp", Type = "rowversion", Nullable = true }
                };

                db.AddColumnsForTables(columns, "dbo.EventLog", "dbo.ChangeLog", "dbo.ChangeLogExclusion");

                return db;
            }
        }
    }
}

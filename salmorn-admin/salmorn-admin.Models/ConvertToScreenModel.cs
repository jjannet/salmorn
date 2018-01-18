using salmorn_admin.DAO;
using salmorn_admin.Models.Logs;
using salmorn_admin.Models.Masters;
using salmorn_admin.Models.Systems;
using salmorn_admin.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models
{
    public static class ConvertToScreenModel
    {
        public static class Logs
        {
            public static FileUpload fileUpload(L_FileUpload item)
            {
                if (item == null) return null;

                return new FileUpload()
                {
                    id = item.id,
                    fileName = item.fileName,
                    ipAddress = item.ipAddress,
                    macAddress = item.macAddress,
                    type = item.type,
                    uploadDate = item.uploadDate,
                    userId = item.userId
                };
            }
        }

        public static class Masters
        {
            public static PostType postType(M_PostType item)
            {
                if (item == null) return null;

                return new PostType()
                {
                    id = item.id,
                    name = item.name
                };
            }

            public static Product product(M_Product item)
            {
                if (item == null) return null;

                var data = new Product()
                {
                    id = item.id,
                    code = item.code,
                    cost = item.cost,
                    createBy = item.createBy,
                    createDate = item.createDate,
                    detail = item.detail,
                    isActive = item.isActive,
                    isPreOrder = item.isPreOrder,
                    isUseStock = item.isUseStock,
                    name = item.name,
                    note = item.note,
                    preEnd = item.preEnd,
                    preStart = item.preStart,
                    price = item.price,
                    qtyShippingPriceCeiling = item.qtyShippingPriceCeiling,
                    shippintPriceRate = item.shippintPriceRate,
                    unitName = item.unitName,
                    updateBy = item.updateBy,
                    updateDate = item.updateDate,
                    weight = item.weight,
                    isDelete = item.isDelete,
                    isManualPickup = item.isManualPickup,
                    pickupAt = item.pickupAt,
                    stockQrty = item.stockQrty
                };

                if (item.M_Product_Image != null)
                {
                    data.images = new List<FileUpload>();
                    foreach (var i in item.M_Product_Image)
                    {
                        data.images.Add(Logs.fileUpload(i.L_FileUpload));
                    }
                }

                return data;
            }

            public static ProductImage productImage(M_Product_Image item)
            {
                if (item == null) return null;

                var data = new ProductImage()
                {
                    id = item.id,
                    fileId = item.fileId,
                    productId = item.productId
                };

                if (item.L_FileUpload != null) data.file = Logs.fileUpload(item.L_FileUpload);

                return data;
            }
        }

        public static class Systems
        {
            public static Role role(S_Role item)
            {
                if (item == null) return null;

                return new Role()
                {
                    role = item.role,
                    roleName = item.roleName
                };
            }

            public static RoleMapping roleMapping(S_RoleMapping item)
            {
                if (item == null) return null;

                var data = new RoleMapping()
                {
                    id = item.id,
                    role = item.role,
                    userId = item.userId
                };
                if (item.S_Role != null) data.roleObj = role(item.S_Role);

                return data;
            }

            public static User user(S_User item)
            {
                if (item == null) return null;
                var data = new User()
                {
                    userId = item.userId,
                    createBy = item.createBy,
                    createDate = item.createDate,
                    displayName = item.displayName,
                    email = item.email,
                    isActive = item.isActive,
                    password = item.password,
                    updateBy = item.updateBy,
                    updateDate = item.updateDate
                };
                if (item.S_RoleMapping != null)
                {
                    data.roleMappings = new List<RoleMapping>();

                    foreach (var r in item.S_RoleMapping)
                    {
                        data.roleMappings.Add(roleMapping(r));
                    }
                }

                return data;
            }
        }

        public static class Transactions
        {
            public static OrderD orderD(T_Order_D item)
            {
                if (item == null) return null;
                var data = new OrderD()
                {
                    id = item.id,
                    hId = item.hId,
                    productId = item.productId,
                    qty = item.qty,
                    unitPrice = item.unitPrice
                };

                if (item.M_Product != null) data.product = Masters.product(item.M_Product);

                return data;
            }

            public static Order order(T_Order item)
            {
                if (item == null) return null;
                var data = new Order()
                {
                    id = item.id,
                    paymentId = item.paymentId,
                    address = item.address,
                    code = item.code,
                    email = item.email,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    isPay = item.isPay,
                    isShipping = item.isShipping,
                    shippingDateStart = item.shippingDateStart,
                    shippingDateEnd = item.shippingDateEnd,
                    shippingDate = item.shippingDate,
                    orderDate = item.orderDate,
                    payDate = item.payDate,
                    province = item.province,
                    shippingPrice = item.shippingPrice,
                    tel = item.tel,
                    totalPrice = item.totalPrice,
                    totalProductPrice = item.totalProductPrice,
                    zipCode = item.zipCode,
                    isMeetReceive = item.isMeetReceive,
                    isActive = item.isActive,
                    isCreateShipping = item.isCreateShipping,
                    createBy = item.createBy,
                    createDate = item.createDate,
                    updateBy = item.updateBy,
                    updateDate = item.updateDate,
                    productId = item.productId,
                    qty = item.qty,
                    select = false,
                    unitPrice = item.unitPrice,
                    isFinish = item.isFinish,
                    product = Masters.product(item.M_Product)
                };

                return data;
            }

            public static PaymentNotification paymentNotification(T_PaymentNotification item)
            {
                if (item == null) return null;
                var data = new PaymentNotification()
                {
                    id = item.id,
                    fileId = item.fileId,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    orderCode = item.orderCode,
                    paymentDate = item.paymentDate,
                    paymentType = item.paymentType,
                    isActive = item.isActive,
                    isMapping = item.isMapping,
                    money = item.money
                };

                if (item.L_FileUpload != null) data.file = Logs.fileUpload(item.L_FileUpload);

                return data;
            }

            public static Post post(T_Post item)
            {
                if (item == null) return null;

                var data = new Post()
                {
                    id = item.id,
                    title = item.title,
                    detail = item.detail,
                    typeId = item.typeId,
                    isActive = item.isActive,
                    author = item.author,
                    authorId = item.authorId,
                    targetDate = item.targetDate,
                    createDate = item.createDate,
                    updateDate = item.updateDate,
                    updateBy = item.updateBy,
                };

                if (item.M_PostType != null) data.postType = Masters.postType(item.M_PostType);

                return data;
            }

            public static ShippingD shippingD(T_Shipping_D item)
            {
                if (item == null) return null;

                return new ShippingD()
                {
                    id = item.id,
                    hId = item.hId,
                    orderId = item.orderId,
                    code = item.code
                };
            }

            public static ShippingH shippingH(T_Shipping_H item)
            {
                if (item == null) return null;

                var data = new ShippingH()
                {
                    id = item.id,
                    code = item.code,
                    isActive = item.isActive,
                    isShipping = item.isShipping,
                    shippingDate = item.shippingDate,
                    createDate = item.createDate,
                    createBy = item.createBy,
                    updateDate = item.updateDate,
                    updateBy = item.updateBy,
                };

                if (item.T_Shipping_D != null)
                {
                    data.details = new List<ShippingD>();
                    foreach (var d in item.T_Shipping_D)
                    {
                        data.details.Add(shippingD(d));
                    }
                }

                return data;
            }

            public static Shipping shipping(T_Shipping item)
            {
                if (item == null) return null;

                return new Shipping()
                {
                    id = item.id,
                    trackingCode = item.trackingCode,
                    orderId = item.orderId,
                    orderCode = item.orderCode,
                    isActive = item.isActive,
                    isShipping = item.isShipping,
                    shippingDate = item.shippingDate,
                    email = item.email,
                    tel = item.tel,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    address = item.address,
                    province = item.province,
                    zipCode = item.zipCode,
                    createDate = item.createDate,
                    createBy = item.createBy,
                    updateDate = item.updateDate,
                    updateBy = item.updateBy,
                    printCoverQty = item.printCoverQty,

                    order = Transactions.order(item.T_Order)
                };
            }
        }
    }
}

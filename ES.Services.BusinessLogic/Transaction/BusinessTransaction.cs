﻿using ES.Services.BusinessLogic.Interface.Transaction;
using ES.Services.DataAccess.Interface.Transaction;
using ES.Services.DataAccess.Model.CommandModel.Transaction;
using ES.Services.DataAccess.Model.QueryModel.Transaction;
using ES.Services.DataAccess.Repositories.Transaction;
using ES.Services.DataTransferObjects.Request.Transaction;
using ES.Services.DataTransferObjects.Response.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Transaction
{
    public class BusinessTransaction : IBusinessTransaction
    {
        private readonly ITransactionRepository transactionRepository;

        public BusinessTransaction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public POResponseDto AddPurchaseOrder(PORequestDto PoRequestDto)
        {

            #region Section For to save the Purchase Master

            var addPoMasterCM = new AddPoMasterCM()
            {
                PONumber = PoRequestDto.PONumber,
                POTypeCode = PoRequestDto.POTypeCode,
                VendorCode = PoRequestDto.VendorCode,
                PODate = PoRequestDto.PODate,
                POAmendNumber = PoRequestDto.POAmendNumber,
                POAmendDate = PoRequestDto.POAmendDate,
                Reference = PoRequestDto.Reference,
                ReferenceDate = PoRequestDto.ReferenceDate,
                CGSTPercent = PoRequestDto.CGSTPercent,
                SGSTPercent = PoRequestDto.SGSTPercent,
                IGSTPercent = PoRequestDto.IGSTPercent,
                PaymentTerms = PoRequestDto.PaymentTerms,
                DeliveryTerms = PoRequestDto.DeliveryTerms,
                Documents = PoRequestDto.Documents,
                Transport = PoRequestDto.Transport,
                Remarks = PoRequestDto.Remarks
            };

            transactionRepository.AddPoMaster(addPoMasterCM);
            #endregion

            #region Section For to save the PO Details

            foreach (var poDetails in PoRequestDto.GetPORequestDetails)
            {
                var addPoDetailsCMItems = new List<AddPoDetailsCMItems>();

                var cModel = new AddPoDetailsCM();
                var workOrderMasterDetails = new AddPoDetailsCMItems
                {
                    PONumber = poDetails.PONumber,
                    POSerial = poDetails.POSerial,
                    POAmendNumber = poDetails.POAmendNumber,
                    ItemCode = poDetails.ItemCode,
                    UOMCode = poDetails.UOMCode,
                    POQuantity = poDetails.POQuantity,
                    PORate = poDetails.PORate,
                    DiscountPercent = poDetails.DiscountPercent,
                    DiscountValue = poDetails.DiscountValue,
                    ItemRate = poDetails.ItemRate,
                    Amount = poDetails.Amount,
                    DeliveryDate = poDetails.DeliveryDate,
                    ReceivedQuantity = poDetails.ReceivedQuantity,
                    ShortCloseQuantity = poDetails.ShortCloseQuantity,
                    CreatedBy = new Guid(),
                    CreatedDateTime = System.DateTime.UtcNow
                };

                addPoDetailsCMItems.Add(workOrderMasterDetails);

                cModel.AddPoDetailsCMItems = addPoDetailsCMItems;

                // Section to add the work order master information
                transactionRepository.AddPoDetails(cModel);

            }

            #endregion


            return new POResponseDto();
        }

        public POResponseDto UpdatePurchaseOrder(UpdatePORequestDto UpdatePORequestDto)
        {

            #region Section For to save the Purchase Master

            var addPoMasterCM = new AddPoMasterCM()
            {
                PONumber = UpdatePORequestDto.PONumber,
                POTypeCode = UpdatePORequestDto.POTypeCode,
                VendorCode = UpdatePORequestDto.VendorCode,
                PODate = UpdatePORequestDto.PODate,
                POAmendNumber = UpdatePORequestDto.POAmendNumber,
                POAmendDate = UpdatePORequestDto.POAmendDate,
                Reference = UpdatePORequestDto.Reference,
                ReferenceDate = UpdatePORequestDto.ReferenceDate,
                CGSTPercent = UpdatePORequestDto.CGSTPercent,
                SGSTPercent = UpdatePORequestDto.SGSTPercent,
                IGSTPercent = UpdatePORequestDto.IGSTPercent,
                PaymentTerms = UpdatePORequestDto.PaymentTerms,
                DeliveryTerms = UpdatePORequestDto.DeliveryTerms,
                Documents = UpdatePORequestDto.Documents,
                Transport = UpdatePORequestDto.Transport,
                Remarks = UpdatePORequestDto.Remarks
            };

            transactionRepository.UpdatePoMaster(addPoMasterCM);
            #endregion

            #region Section For to save the PO Details

            foreach (var poDetails in UpdatePORequestDto.UpdatePORequestDetails)
            {
                var addPoDetailsCMItems = new List<AddPoDetailsCMItems>();
                var updatePoDetailsCMItems = new List<UpdatePoDetailsCMItems>();

                if (poDetails.IsNew)
                {
                    var cModel = new AddPoDetailsCM();
                    var workOrderMasterDetails = new AddPoDetailsCMItems
                    {
                        PONumber = poDetails.PONumber,
                        POSerial = poDetails.POSerial,
                        POAmendNumber = poDetails.POAmendNumber,
                        ItemCode = poDetails.ItemCode,
                        UOMCode = poDetails.UOMCode,
                        POQuantity = poDetails.POQuantity,
                        PORate = poDetails.PORate,
                        DiscountPercent = poDetails.DiscountPercent,
                        DiscountValue = (poDetails.POQuantity * poDetails.PORate * poDetails.DiscountPercent) / 100,
                        ItemRate = poDetails.Amount / poDetails.POQuantity,
                        Amount = (poDetails.POQuantity * poDetails.PORate) - (poDetails.POQuantity * poDetails.PORate * poDetails.DiscountPercent) / 100,
                        DeliveryDate = poDetails.DeliveryDate,
                        ReceivedQuantity = poDetails.ReceivedQuantity,
                        ShortCloseQuantity = poDetails.ShortCloseQuantity,
                        CreatedBy = new Guid(),
                        CreatedDateTime = System.DateTime.UtcNow
                    };

                    addPoDetailsCMItems.Add(workOrderMasterDetails);

                    cModel.AddPoDetailsCMItems = addPoDetailsCMItems;

                    // Section to add the work order master information
                    transactionRepository.AddPoDetails(cModel);
                }
                else
                {
                    var cModel = new UpdatePoDetailsCM();
                    var workOrderMasterDetails = new UpdatePoDetailsCMItems
                    {
                        PONumber = poDetails.PONumber,
                        POSerial = poDetails.POSerial,
                        POAmendNumber = poDetails.POAmendNumber,
                        ItemCode = poDetails.ItemCode,
                        UOMCode = poDetails.UOMCode,
                        POQuantity = poDetails.POQuantity,
                        PORate = poDetails.PORate,
                        DiscountPercent = poDetails.DiscountPercent,
                        DiscountValue = (poDetails.POQuantity * poDetails.PORate * poDetails.DiscountPercent) / 100,
                        ItemRate = poDetails.Amount / poDetails.POQuantity,
                        Amount = (poDetails.POQuantity * poDetails.PORate) - (poDetails.POQuantity * poDetails.PORate * poDetails.DiscountPercent) / 100,
                        DeliveryDate = poDetails.DeliveryDate,
                        ReceivedQuantity = poDetails.ReceivedQuantity,
                        ShortCloseQuantity = poDetails.ShortCloseQuantity,
                        UpdatedBy = new Guid(),
                        UpdatedDateTime = System.DateTime.UtcNow
                    };

                    updatePoDetailsCMItems.Add(workOrderMasterDetails);

                    cModel.UpdatePoDetailsCMItems = updatePoDetailsCMItems;

                    // Section to add the work order master information
                    transactionRepository.UpdatePoDetails(cModel);
                }

            }

            #endregion


            return new POResponseDto();
        }

        public DeletePOResponseDto DeletePurchaseOrder(DeletePORequestDto DeletePORequestDto)
        {
            transactionRepository.DeletePoMasterAndDetails(DeletePORequestDto.PONumber, DeletePORequestDto.POSerialNo, DeletePORequestDto.IsDeleteFrom);

            return new DeletePOResponseDto();
        }

        #region GRN
        public AddGRNMasterResponseDto AddGRNMasterAndDetails(AddGRNMasterRequestDto addGRNMasterRequestDto)
        {

            #region Section For to save the GRN Master

            var addGRNMasterCM = new AddGRNMasterCM()
            {
                GRNNumber = addGRNMasterRequestDto.GRNNumber,
                GRNDate = addGRNMasterRequestDto.GRNDate,
                ReceivedDate = addGRNMasterRequestDto.ReceivedDate,
                VendorCode = addGRNMasterRequestDto.VendorCode,
                InvoiceNumber = addGRNMasterRequestDto.InvoiceNumber,
                InvoiceDate = addGRNMasterRequestDto.InvoiceDate,
                Remarks = addGRNMasterRequestDto.Remarks,
                CreatedBy = new Guid(),
                CreatedDateTime = System.DateTime.UtcNow
            };

            transactionRepository.AddGRNMaster(addGRNMasterCM);
            #endregion

            #region Section For to save the GRN Details

            foreach (var grnDetails in addGRNMasterRequestDto.GetAddGRNDetailsList)
            {
                var addGRNDetailsCMItemsList = new List<AddGRNDetailsCMItems>();

                var cModel = new AddGRNDetailsCM();
                var AddPoDetailsCMItems = new AddGRNDetailsCMItems
                {
                    GRNNumber = grnDetails.GRNNumber,
                    GRNSerial = grnDetails.GRNSerial,
                    PONumber = grnDetails.PONumber,
                    POSerial = grnDetails.POSerial,
                    ItemCode = grnDetails.ItemCode,
                    ReceivedQuantity = grnDetails.ReceivedQuantity,
                    CreatedBy = new Guid(),
                    CreatedDateTime = System.DateTime.UtcNow
                };

                addGRNDetailsCMItemsList.Add(AddPoDetailsCMItems);

                cModel.AddGRNDetailsCMItems = addGRNDetailsCMItemsList;

                // Section to add the work order master information
                transactionRepository.AddGRNDetails(cModel);
            }

            #endregion


            return new AddGRNMasterResponseDto();
        }

        public UpdateGRNMasterResponseDto UpdateGRNMasterAndDetails(UpdateGRNMasterRequestDto updateGRNMasterRequestDto)
        {
            #region Section For to save the GRN Master

            var addGRNMasterCM = new AddGRNMasterCM()
            {
                GRNNumber = updateGRNMasterRequestDto.GRNNumber,
                GRNDate = updateGRNMasterRequestDto.GRNDate,
                ReceivedDate = updateGRNMasterRequestDto.ReceivedDate,
                VendorCode = updateGRNMasterRequestDto.VendorCode,
                InvoiceNumber = updateGRNMasterRequestDto.InvoiceNumber,
                InvoiceDate = updateGRNMasterRequestDto.InvoiceDate,
                Remarks = updateGRNMasterRequestDto.Remarks
            };

            transactionRepository.UpdateGRNMaster(addGRNMasterCM);
            #endregion

            #region Section For to save the GRN Details

            foreach (var grnDetails in updateGRNMasterRequestDto.GetUpdateGRNDetails)
            {
                var updateGRNDetailsCMItemsList = new List<UpdateGRNDetailsCMItems>();
                var cModel = new UpdateGRNDetailsCM();

                if (!grnDetails.IsNew)
                {

                    var UpdatePoDetailsCMItems = new UpdateGRNDetailsCMItems
                    {
                        GRNNumber = grnDetails.GRNNumber,
                        GRNSerial = grnDetails.GRNSerial,
                        PONumber = grnDetails.PONumber,
                        POSerial = grnDetails.POSerial,
                        ItemCode = grnDetails.ItemCode,
                        ReceivedQuantity = grnDetails.ReceivedQuantity,
                        UpdatedBy = new Guid(),
                        UpdatedDateTime = System.DateTime.UtcNow
                    };

                    updateGRNDetailsCMItemsList.Add(UpdatePoDetailsCMItems);

                    cModel.UpdateGRNDetailsCMItems = updateGRNDetailsCMItemsList;

                    // Section to add the work order master information
                    transactionRepository.UpdateGRNDetails(cModel);
                }
                else
                {
                    var addGRNDetailsCMItemsList = new List<AddGRNDetailsCMItems>();

                    var cModelAddGrn = new AddGRNDetailsCM();
                    var AddPoDetailsCMItems = new AddGRNDetailsCMItems
                    {
                        GRNNumber = grnDetails.GRNNumber,
                        GRNSerial = grnDetails.GRNSerial,
                        PONumber = grnDetails.PONumber,
                        POSerial = grnDetails.POSerial,
                        ItemCode = grnDetails.ItemCode,
                        ReceivedQuantity = grnDetails.ReceivedQuantity,
                        CreatedBy = new Guid(),
                        CreatedDateTime = System.DateTime.UtcNow
                    };

                    addGRNDetailsCMItemsList.Add(AddPoDetailsCMItems);

                    cModelAddGrn.AddGRNDetailsCMItems = addGRNDetailsCMItemsList;

                    // Section to add the work order master information
                    transactionRepository.AddGRNDetails(cModelAddGrn);
                }

            }

            #endregion


            return new UpdateGRNMasterResponseDto();
        }

        public DeleteGRNResponseDto DeleteGRNMasterAndDetails(DeleteGRNRequestDto DeleteGRNRequestDto)
        {
            transactionRepository.DeleteGRNMasterAndDetails(DeleteGRNRequestDto.GRNNumber, DeleteGRNRequestDto.GRNSerial, DeleteGRNRequestDto.IsDeleteFrom);

            return new DeleteGRNResponseDto();
        }

        #endregion
    }
}

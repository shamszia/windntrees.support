using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Snippets
{
    class QueryExpressionReferences
    {
        #region LambdaExpressionSampleCode
        //public PagedRecords<VehicleZoneRecord> GetByPageV2(string username, string filterKeyword = null,
        //    bool breached = false,
        //    bool autodisable = false,
        //    bool descbyregno = false,
        //    bool descbyzonename = false,
        //    int pageSize = 10,
        //    int pageNumber = 1)
        //{
        //    try
        //    {
        //        using (DatabaseContext context = new DatabaseContext())
        //        {
        //            IQueryable<VehicleZone> vehicleZonesFilter = context.VehicleZones.AsQueryable<VehicleZone>();
        //            if (string.IsNullOrEmpty(filterKeyword))
        //            {
        //                Expression<Func<VehicleZone, bool>> keywordExpr = e => e.AppliedBy == username;
        //                vehicleZonesFilter = vehicleZonesFilter.Where(keywordExpr);
        //            }
        //            else
        //            {
        //                Expression<Func<VehicleZone, bool>> keywordExpr = e => ((e.GeoZone.Name.Contains(filterKeyword) || e.Vehicle.RegNo.Contains(filterKeyword) || e.Comments.Contains(filterKeyword)) && e.AppliedBy == username);
        //                vehicleZonesFilter = vehicleZonesFilter.Where(keywordExpr);
        //            }

        //            if (breached)
        //            {
        //                Expression<Func<VehicleZone, bool>> breachedExpr = e => (e.Breached == breached);
        //                vehicleZonesFilter = vehicleZonesFilter.Where(breachedExpr);
        //            }

        //            if (autodisable)
        //            {
        //                Expression<Func<VehicleZone, bool>> disableExpr = e => (e.AutoKillBreach == autodisable);
        //                vehicleZonesFilter = vehicleZonesFilter.Where(disableExpr);
        //            }

        //            //Lambda Expression GroupJoin
        //            IQueryable<VehicleZoneRecord> vehicleZoneRecordsFilter = vehicleZonesFilter
        //                .GroupJoin(context.Vehicles, v => v.VehicleID, g => g.VehicleID, (v, g) => new { v, g })
        //                .SelectMany(v => v.g.DefaultIfEmpty(), (v, g) => new { v.v, g })
        //                .GroupJoin(context.GeoZones, vvg => vvg.v.ZoneID, b => b.ZoneID, (vvg, b) => new { vvg, b })
        //                .SelectMany(vvgb => vvgb.b.DefaultIfEmpty(), (vvgb, b) => new VehicleZoneRecord
        //                {
        //                    VehicleID = vvgb.vvg.v.VehicleID,
        //                    VehicleName = vvgb.vvg.g.RegNo,
        //                    ZoneID = vvgb.vvg.v.ZoneID,
        //                    ZoneName = b.Name,
        //                    ZoneNumber = vvgb.vvg.v.ZoneNumber,
        //                    Breached = vvgb.vvg.v.Breached,
        //                    AutoKillBreach = vvgb.vvg.v.AutoKillBreach,
        //                    Comments = vvgb.vvg.v.Comments,
        //                    AppliedOn = vvgb.vvg.v.AppliedOn,
        //                    AppliedBy = vvgb.vvg.v.AppliedBy,
        //                    UID = vvgb.vvg.v.UID,
        //                    TStamp = vvgb.vvg.v.TStamp
        //                });

        //            IOrderedQueryable<VehicleZoneRecord> orderedFilter = null;
        //            if (descbyregno)
        //            {
        //                orderedFilter = vehicleZoneRecordsFilter.OrderByDescending(o => o.VehicleName);
        //            }
        //            else
        //            {
        //                orderedFilter = vehicleZoneRecordsFilter.OrderBy(o => o.VehicleName);
        //            }

        //            if (descbyzonename)
        //            {
        //                if (descbyregno)
        //                {
        //                    orderedFilter = vehicleZoneRecordsFilter.OrderByDescending(o => o.VehicleName).ThenByDescending(o => o.ZoneName);
        //                }
        //                else
        //                {
        //                    orderedFilter = vehicleZoneRecordsFilter.OrderByDescending(o => o.ZoneName).ThenBy(o => o.VehicleName);
        //                }
        //            }
        //            else
        //            {
        //                if (descbyregno)
        //                {
        //                    orderedFilter = vehicleZoneRecordsFilter.OrderByDescending(o => o.VehicleName).ThenBy(o => o.ZoneName);
        //                }
        //                else
        //                {
        //                    orderedFilter = vehicleZoneRecordsFilter.OrderBy(o => o.ZoneName).ThenBy(o => o.VehicleName);
        //                }
        //            }

        //            List<VehicleZoneRecord> records = orderedFilter.Skip(pageSize * (pageNumber - 1))
        //            .Take(pageSize).ToArray()
        //            .ToList();
        //            int count = vehicleZonesFilter.Count();

        //            return new PagedRecords<VehicleZoneRecord>(records, count);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //} 
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// creates a new amenity in our database
        /// </summary>
        /// <param name="amenity">this is the amenity to be added to db as DTO</param>
        /// <returns>Result of adding the amenityDTO</returns>
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);
        /// <summary>
        /// this will get a specific DTO from the DB
        /// </summary>
        /// <param name="Id">how the amenity will be retrieved</param>
        /// <returns>Successful result of specified amenity DTO</returns>
        Task<AmenityDTO> GetAmenity(int Id);
        /// <summary>
        /// returns all the amenities in the DB
        /// </summary>
        /// <returns>Result of list of amenities as DTOS </returns>
        Task<List<AmenityDTO>> GetAmenities();
        /// <summary>
        /// will update details of a given amenity
        /// </summary>
        /// <param name="amenityDTO">DTO to be updated</param>
        /// <returns>Result of updated amenities</returns>
        Task<AmenityDTO> UpdateAmenity(AmenityDTO amenityDTO);
        /// <summary>
        /// Deletes a specific amenity from DB
        /// </summary>
        /// <param name="Id">specific id to be deleted </param>
        /// <returns></returns>
        Task DeleteAmenity(int Id);
    }
}

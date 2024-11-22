﻿using accounting.Dtos.Packages;
using accounting.entities;
using accounting.interfaces;

namespace accounting.Service
{
    public class PackageService : IPackageService
    {
        private AccountinigDbContext _context = new AccountinigDbContext();

        public int Counter { get; set; } = 0;

        public UserPackageEntity Buy(int userId, int packageId, string transaction)
        {
            UserPackageEntity result = new UserPackageEntity()
            {
                CrateDate = DateTime.Now,
                PackageId = packageId,
                UserId = userId,
                TransactionId = transaction
            };

            try
            {
                UserEntity CurrentUser = _context.Users.FirstOrDefault(x=>x.Id == userId)!;
                PackageEntity package = Get(packageId);
                result.Price = package.Price;
                result.Duration = package.Duration;
                if (CurrentUser != null && package != null)
                {
                    _context.UserPackages.Add(result);
                    _context.SaveChanges();
                    CurrentUser.Expiredate = CurrentUser.Expiredate>=DateTime.Now ? CurrentUser.Expiredate.Value.AddDays(package.Duration) : DateTime.Now.AddDays(package.Duration);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("User Or Package Not Found");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool Chabgeorder(int id, int orderId)
        {
            bool result = false;

            try
            {
                PackageEntity packageEntity = _context.Packages.FirstOrDefault(x => x.Id == id)!;
                if (packageEntity != null) { 
                packageEntity.Order = orderId;
                    _context.Packages.Update(packageEntity);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool ChaneStatus(int id)
        {
            bool result = false;

            try
            {
                PackageEntity packageEntity = _context.Packages.FirstOrDefault(x => x.Id == id)!;
                if (packageEntity != null)
                {
                    packageEntity.isDeactive = !packageEntity.isDeactive;
                    _context.Packages.Update(packageEntity);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public PackageEntity Creat(CreateDto input)
        {
            PackageEntity package = new PackageEntity();
            try
            {
                int order = 10;
                try
                {

                }
                catch (Exception)
                {

                   PackageEntity LastPackage = _context.Packages.OrderByDescending(x=>x.Order).FirstOrDefault()!;
                    if(LastPackage != null)
                    {
                        order += LastPackage.Order;
                    }
                }
                package.CrateDate = DateTime.Now;
                package.Duration = input.Duration;
                package.Price = input.Price;
                package.Description = input.Description;
                package.Title = input.Title;
                package.isDeactive = false;
                package.Order = order;

                _context.Packages.Add(package);
                _context.SaveChanges();

            }
            catch (Exception ex) 
            {

            }
            return package;
        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                PackageEntity packageEntity = new PackageEntity()
                {
                    Id = id,
                };

                    _context.Packages.Remove(packageEntity);
                    _context.SaveChanges();
                    result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public PackageEntity Get(int id)
        {
            ++Counter;
            return _context.Packages.FirstOrDefault(x => x.Id == id)!;
        }

        public List<PackageEntity> GetAll()
        {
            return _context.Packages.OrderByDescending(x => x.CrateDate).ToList();
        }

        public PackageEntity Update(UpdateDto input)
        {
            PackageEntity packageEntity = _context.Packages.FirstOrDefault(x => x.Id == input.Id)!;

            try
            {
                if (packageEntity != null)
                {
                    packageEntity.Description = input.Description;
                    packageEntity.Title = input.Title;
                    packageEntity.Duration = input.Duration;
                    packageEntity.Price = input.Price;
                    _context.Packages.Update(packageEntity);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return packageEntity!;
        }
    }


}

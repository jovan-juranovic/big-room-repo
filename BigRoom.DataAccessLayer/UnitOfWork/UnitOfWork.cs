﻿using System;
using BigRoom.DataAccessLayer.Repositories;
using BigRoom.Model;

namespace BigRoom.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private BigRoomContext ctx = new BigRoomContext();
        private IRepository<User> userRepository; 
        private IRepository<Category> categoryRepository;
        private IRepository<Product> productRepository;
        private IRepository<ProductReview> reviewRepository;
        private IRepository<Cart> cartRepository;
        private IRepository<CartItem> cartItemRepository;
        private IRepository<Country> countryRepository;

        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new Repository<User>(ctx);
                }

                return userRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new Repository<Category>(ctx);
                }

                return categoryRepository;
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new Repository<Product>(ctx);
                }

                return productRepository;
            }
        }

        public IRepository<ProductReview> ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new Repository<ProductReview>(ctx);
                }

                return reviewRepository;
            }
        }

        public IRepository<Cart> CartRepository
        {
            get
            {
                if (this.cartRepository == null)
                {
                    this.cartRepository = new Repository<Cart>(ctx);
                }

                return cartRepository;
            }
        }

        public IRepository<CartItem> CartItemRepository
        {
            get
            {
                if (this.cartItemRepository == null)
                {
                    this.cartItemRepository = new Repository<CartItem>(ctx);
                }

                return cartItemRepository;
            }
        }

        public IRepository<Country> CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                {
                    this.countryRepository = new Repository<Country>(ctx);
                }

                return countryRepository;
            }
        }

        public int Save()
        {
            return ctx.SaveChanges();
        }

        #region IDisposable

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion
    }
}

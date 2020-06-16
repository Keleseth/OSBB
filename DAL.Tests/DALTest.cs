using System;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace DAL.Tests
{
    [TestFixture]
    public class DALTest
    {
        private IRepository<Product> _productRepository;
        private Mock<DbSet<Product>> _mockDbSet;
        private Mock<DbContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DbContext>()
                .Options;
            _mockContext = new Mock<DbContext>(opt);
            _mockDbSet = new Mock<DbSet<Product>>();

            _mockContext
                .Setup(context =>
                    context.Set<Product>(
                    ))
                .Returns(_mockDbSet.Object);

            _productRepository = new Repository<Product>(_mockContext.Object);
        }

        [Test]
        public void Repository_CalledInsertOneTime_InsertCorrect()
        {
            // Arrange
            var expectedProduct = new Mock<Product>().Object;

            //Act
            _productRepository.Insert(expectedProduct);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedProduct
                ), Times.Once());
        }

        [Test]
        public void Repository_CalledRemove_RemovedCorrect()
        {
            // Arrange
            var id = Guid.NewGuid();

            var expectedProduct = new Product { Id = id };
            _mockDbSet.Setup(mock => mock.Find(expectedProduct.Id)).Returns(expectedProduct);

            // Act

            var foundProduct = _productRepository.GetById(id);
            _productRepository.Remove(foundProduct);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedProduct.Id
                ), Times.Once());

            _mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedProduct
                ), Times.Once());
        }
    }
}
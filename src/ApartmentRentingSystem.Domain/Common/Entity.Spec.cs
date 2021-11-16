﻿namespace ApartmentRentingSystem.Domain.Common
{
    using Models.Landlords;
    using FluentAssertions;
    using Xunit;

    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            // Arrange
            var first = new Landlord("First", new PhoneNumber("+123", "First")).SetId(1);
            var second = new Landlord("Second", new PhoneNumber("+321", "Second")).SetId(1);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            // Arrange
            var first = new Landlord("First", new PhoneNumber("+123","First")).SetId(1);
            var second = new Landlord("Second", new PhoneNumber("+321","Second")).SetId(2);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {
        public static TEntity SetId<TEntity>(this TEntity entity, int id)
            where TEntity : Entity<int>
            => (entity.SetId<int>(id) as TEntity)!;

        private static Entity<T> SetId<T>(this Entity<T> entity, int id)
            where T : struct
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] {id});

            return entity;
        }
    }
}
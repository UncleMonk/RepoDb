﻿using System;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using RepoDb.IntegrationTests.Setup;
using Shouldly;

namespace RepoDb.IntegrationTests
{
    [TestFixture]
    public class TestSpatialDataTypeMapping : FixturePrince
    {
        [Test]
        public void TestGeographyDataType()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestGeometryDataType()
        {

            //arrange
            var fixtureData = new Models.TypeMapSpatial
            {
                geometry_column = "LINESTRING (-122.36 47.656, -122.343 47.656)"
            };

            //act
            var sut = new DbRepository<SqlConnection>(Constants.TestDatabase);
            var returnedId = sut.Insert(fixtureData);

            //TODO: support guid primary key

            //assert
            var saveData = sut.Query<Models.TypeMapSpatial>(top: 1).FirstOrDefault();
            saveData.ShouldNotBeNull();
            saveData.geometry_column.ShouldBe(fixtureData.geometry_column);
        }
    }
}
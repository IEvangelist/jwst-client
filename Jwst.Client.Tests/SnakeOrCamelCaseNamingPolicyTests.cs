// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Jwst.Client.Tests;

public class SnakeOrCamelCaseNamingPolicyTests
{
    [Fact]
    public void ConvertNameNullNameThrows()
    {
        var policy = new SnakeOrCamelCaseNamingPolicy();
        Assert.Throws<ArgumentNullException>(() => policy.ConvertName(null!));
    }

    [Theory]
    [InlineData("statusCode", "StatusCode")]
    [InlineData("observation_id", "ObservationId")]
    [InlineData("file_type", "FileType")]
    [InlineData("error", "Error")]
    public void ConvertNameCorrectlyConverts(string name, string expected)
    {
        // Arrange
        var policy = new SnakeOrCamelCaseNamingPolicy();

        // Act
        var actual = policy.ConvertName(name);

        // Assert
        Assert.Equal(expected, actual);
    }
}

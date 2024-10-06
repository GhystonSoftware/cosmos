import random
import string

# Generate a random name for a star
def generateName():
    return ''.join(random.choices(string.ascii_uppercase, k=3)) + ' ' + ''.join(random.choices(string.digits, k=5))

# Generate a random RA coordinate for a star
def generateRA():
    return random.uniform(0, 360)

# Generate a random DEC coordinate for a star
def generateDEC():
    return random.uniform(-90, 90)

# Generate a random parallax for a star
def generateParallax():
    return random.uniform(0, 0.999)

# Generate a random luminosity for a star
def generateLuminosity():
    return random.uniform(0, 0.999)

# Generate a random pseudoColor for a star (as a wavelength)
def generatePseudoColor():
    return random.uniform(400, 700)

# Generate a list of 500 stars
def generateStars():
    stars = []
    for i in range(500):
        star = {
            'name': generateName(),
            'RA': generateRA(),
            'DEC': generateDEC(),
            'parallax': generateParallax(),
            'luminosity': generateLuminosity(),
            'pseudoColor': generatePseudoColor()
        }
        stars.append(star)
    return stars

# Write the list of stars to a file as SQL insert statements

def writeStarsToFile(stars):
    with open('SeedTestStars.sql', 'w') as file:
        file.write("INSERT INTO stars (Name, RightAscensionInDegrees, DeclinationInDegrees, Parallax, Luminosity, PseudoColour) VALUES \n")
        for star in stars:
            file.write("    ('{}', {}, {}, {}, {}, {}),\n".format(star['name'], star['RA'], star['DEC'], star['parallax'], star['luminosity'], star['pseudoColor']))
        file.seek(file.tell() - 3, 0)
        file.write(";")

stars = generateStars()
writeStarsToFile(stars)

# After this, we take the stars and generate VisibleStar records for them in the sky for each planet.
# A VisibleStar record contains:
# - The ID of the star in the stars table (1-500)
# - The ID of the StarMap, which is the ID of the planet in the planets table (1-9)
# - The X and Y coordinates of the star on the StarMap (0-1000)
# - The brightness of the star (0-1)


planetIds = range(1, 10)

def generateVisibleStars(stars):
    visibleStars = []
    for star in stars:
        for planetId in planetIds:
            visibleStar = {
                'starId': stars.index(star) + 1,
                'planetId': planetId,
                'longitude': round(random.uniform(0, 360), 2),
                'latitude': round(random.uniform(0, 90), 2),
                'brightness': round(random.uniform(0, 0.999), 3)
            }
            
            visibleStars.append(visibleStar)
    return visibleStars

def writeVisibleStarsToFile(visibleStars):
    with open('SeedTestVisibleStars.sql', 'w') as file:
        # Split the visible stars into groups of 1000 per insert statement
        for i in range(0, len(visibleStars), 1000):
            file.write("INSERT INTO VisibleStars (StarId, StarMapId, Longitude, Latitude, Brightness) VALUES \n")
            for visibleStar in visibleStars[i:i+1000]:
                file.write("    ({}, {}, {}, {}, {}),\n".format(visibleStar['starId'], visibleStar['planetId'], visibleStar['longitude'], visibleStar['latitude'], visibleStar['brightness']))
            file.seek(file.tell() - 3, 0)
            file.write(";\n")

visibleStars = generateVisibleStars(stars)
writeVisibleStarsToFile(visibleStars)

# Finally, we seed the StarMap table so each planet has a StarMap record.
# A StarMap record contains:
# - The ID of the planet in the planets table (1-9)

def generateStarMaps():
    starMaps = []
    for planetId in planetIds:
        starMap = {
            'planetId': planetId
        }
        starMaps.append(starMap)
    return starMaps

def writeStarMapsToFile(starMaps):
    with open('SeedTestStarMaps.sql', 'w') as file:
        file.write("INSERT INTO StarMaps (PlanetId) VALUES \n")
        for starMap in starMaps:
            file.write("    ({}),\n".format(starMap['planetId']))
        file.seek(file.tell() - 3, 0)
        file.write(";")
        
starMaps = generateStarMaps()
writeStarMapsToFile(starMaps)


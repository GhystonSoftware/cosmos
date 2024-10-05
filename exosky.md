## Deployment

MVP tasks:
- Create a repo
- Clone project template
- Deploy to Azure

## Test data

MVP tasks:
- Set up database initial schema
- Export 10 exoplanets form NASA dataset and save in database
- Export stars data from Gaia for 1 reference planet (Earth??) and save in db

### Schema
- Exoplanets
  - Id
  - Name
  - RA
  - Dec
  - Distance
  - ... other metadata we want to display
- Star maps
  - Id
  - ExoplanetId
- Stars
  - Id
  - StarMapId
  - Name
  - x
  - y
  - ApparentBrightness
  - ... other metadata we want to display
- Constellations
  - Id
  - Name
  - CreatedByUserName
  - CreateAt
- ConstellationLines
  - Id
  - ConstellationId
  - Star1Id
  - Star2Id

## Frontend

Circular Maps for a single hemisphere

These are what the requests and responses to the gets stars endpoint will look like

request
```json
{
    "exoplanetId": number
}
```

response 
```json
"stars" : [
{
"x": number
"y": number
"apparentBrightness": number/decimal
}
]
```

MVP tasks:
- dropdown to select exoplanet
- plot the stars (size proportional to apparent brightness)
- Allow constellation mapping on the frontend

Stretch tasks:
- Allow constellation saving/fetching/updating with backend
- Display planet data from exoplanets (size, orbit path e.t.c., solar system map)
- stars data
- 3d?????!!!!!


## Backend

### GaiaApiService

- Create request payload
- Send request to gaia API
- Parse response to object

Fields to fetch from API: position in sky (RA, Dec), distance, Name, ID, Brightness

### CoordinateTransformationService

- Project polar coordinates (& distance) to x,y coordinates for display on map
- Convert between sexagesimal and decimal angles

### WebApi

- Handle requests from client app
  - Get stars request
  - Get exoplanets
  - Get, Save, Update, Delete constellations

# cosmos

## Dev setup

### Backend
Run the following commands in your project directory to set up the backend:
- `docker-compose up -d`
- `dotnet tool restore`

### Frontend

Run `npm install` inside `./Web/client-app` to install the dependencies.

To run the app from command line, run `npm run dev` inside the same directory.

### Computations

- Absolute magnitude (M), computed with the apparent magnitude (m) and the distance (d in parsec): m - M = 5log(d/10)
source: https://astronomy.swin.edu.au/cosmos/A/Absolute+Magnitude

- 
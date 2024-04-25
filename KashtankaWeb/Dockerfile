FROM node:latest AS build
ARG API_URL
ENV API_URL $API_URL
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN node replace-env.js
RUN npm run build
#STAGE 2
FROM nginx:mainline-alpine3.18-perl
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/kashtanka-web/browser /usr/share/nginx/html

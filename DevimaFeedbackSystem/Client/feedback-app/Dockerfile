FROM node:20 AS build

WORKDIR /app

COPY Client/feedback-app/package*.json ./
RUN npm install

COPY Client/feedback-app/ .
RUN npm run build --prod

FROM nginx:alpine AS production
COPY --from=build /app/dist/feedback-app/browser /usr/share/nginx/html/
COPY Client/feedback-app/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
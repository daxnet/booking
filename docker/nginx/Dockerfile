FROM nginx:1.23.3-alpine
COPY localhost.key /etc/nginx/localhost.key
COPY localhost.crt /etc/nginx/localhost.crt
COPY nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]

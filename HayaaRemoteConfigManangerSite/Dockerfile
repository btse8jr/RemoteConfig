FROM nodejs:latest
RUN mkdir -p /app
WORKDIR /app
COPY . /app
RUN npm install
EXPOSE 30001
CMD ["npm","start"]

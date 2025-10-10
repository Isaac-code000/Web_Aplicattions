const fetchAPI = fetch('http://localhost:5018/times', {
        method: 'GET',
        headers: {
            'contentType': "application/json"
        }
    }
    
).then(response => response.json()).then(data => console.log(data));

console.log(fetchAPI);
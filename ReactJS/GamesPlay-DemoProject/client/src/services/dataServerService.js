const server = `http://localhost:3030`;

const requester = async (method, endpoint, data) => {
    
    
    const response = await fetch(server + endpoint, {
        method,
        headers :{"Content-Type": "Application/JSON"},
        body: JSON.stringify(data)
    });
    
    //todo: handle server not found
    const result = response.status === 204 ? {} : await response.json();

    if (response.status !== 200) {
        throw result
    }

    return result;
};


export const get = requester.bind(null, 'GET');
export const post = requester.bind(null, 'POST');
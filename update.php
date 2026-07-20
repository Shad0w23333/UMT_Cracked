<?php
// Use the official raw URL format for GitHub files
$file_url = 'https://raw.githubusercontent.com/NewAgent2025/NewAgentsSite/main/Update_UMT_Cracked/UMT_Cracked.exe';

// Optional: Stream the file content directly into a temporary variable or check headers
// To check if the remote file exists/is reachable, you can use a basic header check or @file_get_contents
$file_data = @file_get_contents($file_url);

if ($file_data === false) {
    http_response_code(404);
    echo "File not found or unable to download from GitHub!";
    exit;
}

// Set headers for file download
header('Content-Description: File Transfer');
header('Content-Type: application/octet-stream');
header('Content-Disposition: attachment; filename="UMT_Cracked.exe"');
header('Expires: 0');
header('Cache-Control: must-revalidate');
header('Pragma: public');
header('Content-Length: ' . strlen($file_data));

// Clear output buffer
flush();

// Output the raw file data
echo $file_data;
exit;
